﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }
        [HttpGet("{reviewerId}/reviews")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto createReviewer)
        {
            if (createReviewer == null)
                return BadRequest(ModelState);
            var reviewer = _reviewerRepository.GetReviewers().Where(c => c.FirstName.Trim().ToUpper() == createReviewer.FirstName.TrimEnd().ToUpper() && c.LastName.Trim().ToUpper() == createReviewer.LastName.TrimEnd().ToUpper()).FirstOrDefault();
            if (reviewer != null)
            {
                ModelState.AddModelError("", "Reviewer already exists");
                return StatusCode(422, ModelState);
            }
            var reviewerMap = _mapper.Map<Reviewer>(createReviewer);
            if (!_reviewerRepository.CreateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {reviewerMap.FirstName}");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");

        }

        [HttpPut("{reviewerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDto updateReviewer)
        {
            if (updateReviewer == null)
                return BadRequest(ModelState);
            if (reviewerId != updateReviewer.Id)
                return BadRequest(ModelState);
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reviewerMap = _mapper.Map<Reviewer>(updateReviewer);
            if (!_reviewerRepository.UpdateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {reviewerMap.FirstName}");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully updated");
        }


        [HttpDelete("{reviewerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviewerToDelete = _reviewerRepository.GetReviewer(reviewerId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_reviewerRepository.DeleteReviewer(reviewerToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {reviewerToDelete.FirstName}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
