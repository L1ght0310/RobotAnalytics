using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotAnalytics.Contracts.Commands
{
    public record MoveJCommand
    {
        public required double[] JointAngles { get; init; }

        public required double Velocity { get; init; }

        public required double Acceleration { get; init; }

    }
}
