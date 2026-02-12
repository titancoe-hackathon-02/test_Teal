using System.ComponentModel.DataAnnotations;

namespace MachineMaintenance.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Machine ID")]
        [StringLength(50)]
        public string MachineId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Machine Name")]
        [StringLength(100)]
        public string MachineName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Maintenance Type")]
        public MaintenanceType MaintenanceType { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        [Display(Name = "Scheduled Date")]
        [DataType(DataType.Date)]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [Display(Name = "Assigned Technician")]
        [StringLength(100)]
        public string Technician { get; set; } = string.Empty;

        [Display(Name = "Estimated Hours")]
        [Range(0, 1000)]
        public decimal? EstimatedHours { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }

        [Display(Name = "Description")]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Display(Name = "Additional Notes")]
        [StringLength(1000)]
        public string? Notes { get; set; }

        [Display(Name = "Actual Hours")]
        [Range(0, 1000)]
        public decimal? ActualHours { get; set; }

        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }
    }

    public enum MaintenanceType
    {
        Preventive,
        Corrective,
        Predictive,
        Emergency
    }

    public enum Priority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum MaintenanceStatus
    {
        Scheduled,
        [Display(Name = "In Progress")]
        InProgress,
        Completed,
        Pending,
        Cancelled
    }
}
