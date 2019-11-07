namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Requests
{
    using System;

    public abstract class CrabModificationRequest { }

    /// <summary>Request wrapper for Id based requests</summary>
    public abstract class CrabIdRequest : CrabModificationRequest
    {
        public int Id { get; }

        private protected CrabIdRequest(int id) => Id = id;

        public static implicit operator int(CrabIdRequest crabIdRequest)
        {
            if (crabIdRequest == null)
                throw new ArgumentNullException(nameof(crabIdRequest));

            return crabIdRequest.Id;
        }
    }
}
