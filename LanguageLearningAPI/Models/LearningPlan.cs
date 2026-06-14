using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageLearningAPI.Models
{
    public class LearningPlan
    {
        [Key]
        public int PlanID { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public User? User { get; set; }

        /// <summary>
        /// IDs of the translation groups assigned to this learning plan.
        /// Stored as JSONB in PostgreSQL (see ApplicationDbContext).
        /// </summary>
        public List<int> GroupIDs { get; set; } = new();
    }
}
