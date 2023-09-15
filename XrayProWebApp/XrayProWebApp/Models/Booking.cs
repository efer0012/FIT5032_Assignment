using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace XrayProWebApp.Models
{
    public partial class Booking
    {
        public Booking()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public string RoomId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime Created { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public System.TimeSpan Time { get; set; }

        [Required]
        [StringLength(50)]
        public string XrayType { get; set; }

        [Required]
        [StringLength(255)]
        public string XrayDescription { get; set; }

        [Required]
        [StringLength(100)]
        public string ReferralDoctorName { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string ReferralDoctorPhone { get; set; }

        [Required]
        public int BookingStatus { get; set; }

        [StringLength(255)]
        public string XrayOutcomeDesc { get; set; }

        public string NurseId { get; set; }

        [Range(1, 5)] // Assuming ratings are from 1 to 5
        public Nullable<int> CustomerRatings { get; set; }

        [StringLength(500)]
        public string CustomerFeedback { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
