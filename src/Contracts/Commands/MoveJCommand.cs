using System.ComponentModel.DataAnnotations;

namespace RobotAnalytics.Contracts.Commands
{
    public record MoveJCommand
    {
        [MinLength(6, ErrorMessage = "JointAnglesは6軸分指定してください。")]
        [MaxLength(6, ErrorMessage = "JointAnglesは6軸分指定してください。")]
        
        public required double[] JointAngles { get; init; }

        [Range(0, 10)]
        public required double Velocity { get; init; }

        [Range(0, 10)]
        public required double Acceleration { get; init; }

    }
}
