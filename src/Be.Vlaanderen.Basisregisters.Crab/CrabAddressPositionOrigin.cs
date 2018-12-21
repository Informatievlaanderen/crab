namespace Be.Vlaanderen.Basisregisters.Crab
{
    public enum CrabAddressPositionOrigin
    {
        ManualIndicationFromLot = 1,
        ManualIndicationFromParcel = 2,
        ManualIndicationFromBuilding = 3,
        ManualIndicationFromMailbox = 4,
        ManualIndicationFromUtilityConnection = 5,
        ManualIndicationFromAccessToTheRoad = 6,
        ManualIndicationFromEntryOfBuilding = 7,
        ManualIndicationFromStand = 8,
        ManualIndicationFromBerth = 9,
        DerivedFromBuilding = 10,
        DerivedFromParcelGrb = 11,
        DerivedFromParcelCadastre = 12,
        InterpolatedBasedOnAdjacentHouseNumbersBuilding = 13,
        InterpolatedBasedOnAdjacentHouseNumbersParcelGrb = 14,
        InterpolatedBasedOnAdjacentHouseNumbersParcelCadastre = 15,
        InterpolatedBasedOnRoadConnection = 16,
        DerivedFromStreet = 17,
        DerivedFromMunicipality = 18,
    }
}
