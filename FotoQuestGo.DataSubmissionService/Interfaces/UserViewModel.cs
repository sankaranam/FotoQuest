using System;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class UserViewModel
    {
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
