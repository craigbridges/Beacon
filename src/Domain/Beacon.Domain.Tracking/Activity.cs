namespace Beacon.Domain.Tracking
{
    using Beacon.Domain.SharedKernel.Risk;

    /// <summary>
    /// Aggregate root that represents an activity being undertaken by a user
    /// </summary>
    public class Activity : IAggregateRoot
    {
        protected Activity() { }

        //private Activity()
        //{
        //    // TODO: capture: name, notes, user, type, risk, estimate duration, alert action
        //}

        /// <summary>
        /// Gets the unique location ping identifier
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets the date and time the devices was created
        /// </summary>
        public DateTime DateCreated { get; protected set; }

        /// <summary>
        /// Gets the date and time the device was last modified
        /// </summary>
        public DateTime DateModified { get; protected set; }

        /// <summary>
        /// Gets a list of device related domain events that have not been published
        /// </summary>
        public List<IDomainEvent> UnpublishedEvents { get; } = new();

        /// <summary>
        /// Gets the name of the activity
        /// </summary>
        public string Name { get; protected set; } = default!;

        /// <summary>
        /// Gets any notes made against the activity (e.g. location/venue)
        /// </summary>
        public string? Notes { get; protected set; }

        /// <summary>
        /// Gets the user information of the person undertaking the activity
        /// </summary>
        public UserInformation User { get; protected set; } = default!;

        /// <summary>
        /// Gets the activity type
        /// </summary>
        public ActivityType ActivityType { get; protected set; }

        /// <summary>
        /// Gets the activities assessed risk level
        /// </summary>
        public RiskLevel Risk { get; protected set; }

        /// <summary>
        /// Gets the date and time the activity started
        /// </summary>
        public DateTime? DateStarted { get; protected set; }

        /// <summary>
        /// Gets the geographical coordinate where the activity started (if known)
        /// </summary>
        public GeoCoordinate? StartedAtCoordinate { get; protected set; }

        /// <summary>
        /// Starts the activity
        /// </summary>
        /// <param name="coordinate">The starting coordinate (optional)</param>
        /// <returns>The result of the operation</returns>
        public Result Start(GeoCoordinate? coordinate = null)
        {
            var status = GetStatus();

            if (status == ActivityStatus.InProgress || status == ActivityStatus.Overrun)
            {
                return Result.Failure($"{this} is currently in progress.");
            }
            else if (status == ActivityStatus.Concluded)
            {
                return Result.Failure($"{this} has already concluded.");
            }
            else
            {
                var now = DateTime.UtcNow;

                DateStarted = now;
                StartedAtCoordinate = coordinate;

                UnpublishedEvents.Add
                (
                    new ActivityStartedEvent()
                    {
                        ActivityId = Id,
                        ActivityName = Name,
                        Notes = Notes,
                        User = User,
                        ActivityType = ActivityType,
                        Risk = Risk,
                        DateStarted = now
                    }
                );

                return Result.Success();
            }
        }

        /// <summary>
        /// Gets the estimated duration of the activity
        /// </summary>
        public TimeSpan EstimatedDuration { get; protected set; }

        /// <summary>
        /// Gets the date and time the activity ended
        /// </summary>
        public DateTime? DateEnded { get; protected set; }

        /// <summary>
        /// Gets the geographical coordinate where the activity ended (if known)
        /// </summary>
        public GeoCoordinate? EndedAtCoordinate { get; protected set; }

        /// <summary>
        /// Ends the activity
        /// </summary>
        /// <param name="coordinate">The end coordinate (optional)</param>
        /// <returns>The result of the operation</returns>
        public Result End(GeoCoordinate? coordinate = null)
        {
            var status = GetStatus();

            if (status == ActivityStatus.NotStarted)
            {
                return Result.Failure($"{this} has not yet started.");
            }
            else if (status == ActivityStatus.Concluded)
            {
                return Result.Failure($"{this} has already concluded.");
            }
            else
            {
                var now = DateTime.UtcNow;

                DateEnded = now;
                EndedAtCoordinate = coordinate;

                UnpublishedEvents.Add
                (
                    new ActivityEndedEvent()
                    {
                        ActivityId = Id,
                        ActivityName = Name,
                        User = User,
                        ActivityType = ActivityType,
                        DateEnded = now
                    }
                );

                return Result.Success();
            }
        }

        /// <summary>
        /// Gets the current status of the activity
        /// </summary>
        public ActivityStatus GetStatus()
        {
            if (DateStarted == null)
            {
                return ActivityStatus.NotStarted;
            }
            else if (DateEnded.HasValue && DateEnded <= DateTime.UtcNow)
            {
                return ActivityStatus.Concluded;
            }
            else
            {
                var currentDuration = DateTime.UtcNow - DateStarted.Value;

                if (currentDuration > EstimatedDuration)
                {
                    return ActivityStatus.Overrun;
                }
                else
                {
                    return ActivityStatus.InProgress;
                }
            }
        }

        // TODO:
        // action on failure to end activity (optional - but can choose alert level to raise)

        public override string ToString() => Name;
    }
}
