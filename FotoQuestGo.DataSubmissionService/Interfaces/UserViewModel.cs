using System;
using System.ComponentModel.DataAnnotations;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class UserViewModel
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
