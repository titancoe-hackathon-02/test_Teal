using System.ComponentModel.DataAnnotations;

namespace MachineMaintenanceWPF.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MachineId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string MachineName { get; set; } = string.Empty;

        [Required]
        public MaintenanceType MaintenanceType { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Technician { get; set; } = string.Empty;

        [Range(0, 1000)]
        public decimal? EstimatedHours { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        [Range(0, 1000)]
        public decimal? ActualHours { get; set; }

        public DateTime? CompletionDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

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
        InProgress,
        Completed,
        Pending,
        Cancelled
    }
}
