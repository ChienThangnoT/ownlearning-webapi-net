using WebAPI.Repository.Models;

namespace WebAPI.Repository.Data
{
    public class AccountModel
    {
        public int AccountId { get; set; }

        public string? AccountImg { get; set; }

        public string? AccountName { get; set; }

        public string? AccountPassword { get; set; }

        public string? AccountEmail { get; set; }

        public string? AccountPhone { get; set; }

        public bool? AccountIsActive { get; set; }

        public int? RoleId { get; set; }

        public string? SocialId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? Biography { get; set; }

    }
}
