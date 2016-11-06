using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RaceParty.FlagMan.ProjectCars
{
    [DataContract]
    public class Buildinfo
    {
        [DataMember(Name = "mBuildVersionNumber")]
        public int MBuildVersionNumber { get; set; }

        [DataMember(Name = "mVersion")]
        public int MVersion { get; set; }
    }

    [DataContract]
    public class GameStates
    {
        [DataMember(Name = "mGameState")]
        public int MGameState { get; set; }

        [DataMember(Name = "mRaceState")]
        public int MRaceState { get; set; }

        [DataMember(Name = "mSessionState")]
        public int MSessionState { get; set; }
    }

    [DataContract]
    public class MParticipantInfo
    {
        [DataMember(Name = "mCurrentLap")]
        public int MCurrentLap { get; set; }

        [DataMember(Name = "mCurrentLapDistance")]
        public double MCurrentLapDistance { get; set; }

        [DataMember(Name = "mCurrentSector")]
        public int MCurrentSector { get; set; }

        [DataMember(Name = "mIsActive")]
        public bool MIsActive { get; set; }

        [DataMember(Name = "mLapsCompleted")]
        public int MLapsCompleted { get; set; }

        [DataMember(Name = "mName")]
        public string MName { get; set; }

        [DataMember(Name = "mRacePosition")]
        public int MRacePosition { get; set; }

        [DataMember(Name = "mWorldPosition")]
        public IList<double> MWorldPosition { get; set; }
    }

    [DataContract]
    public class Participants
    {
        [DataMember(Name = "mNumParticipants")]
        public int MNumParticipants { get; set; }

        [DataMember(Name = "mParticipantInfo")]
        public IList<MParticipantInfo> MParticipantInfo { get; set; }

        [DataMember(Name = "mViewedParticipantIndex")]
        public int MViewedParticipantIndex { get; set; }
    }

    [DataContract]
    public class UnfilteredInput
    {
        [DataMember(Name = "mUnfilteredBrake")]
        public int MUnfilteredBrake { get; set; }

        [DataMember(Name = "mUnfilteredClutch")]
        public int MUnfilteredClutch { get; set; }

        [DataMember(Name = "mUnfilteredSteering")]
        public int MUnfilteredSteering { get; set; }

        [DataMember(Name = "mUnfilteredThrottle")]
        public int MUnfilteredThrottle { get; set; }
    }

    [DataContract]
    public class VehicleInformation
    {
        [DataMember(Name = "mCarClassName")]
        public string MCarClassName { get; set; }

        [DataMember(Name = "mCarName")]
        public string MCarName { get; set; }
    }

    [DataContract]
    public class EventInformation
    {
        [DataMember(Name = "mLapsInEvent")]
        public int MLapsInEvent { get; set; }

        [DataMember(Name = "mTrackLength")]
        public double MTrackLength { get; set; }

        [DataMember(Name = "mTrackLocation")]
        public string MTrackLocation { get; set; }

        [DataMember(Name = "mTrackVariation")]
        public string MTrackVariation { get; set; }
    }

    [DataContract]
    public class Timings
    {
        [DataMember(Name = "mBestLapTime")]
        public int MBestLapTime { get; set; }

        [DataMember(Name = "mCurrentSector1Time")]
        public int MCurrentSector1Time { get; set; }

        [DataMember(Name = "mCurrentSector2Time")]
        public int MCurrentSector2Time { get; set; }

        [DataMember(Name = "mCurrentSector3Time")]
        public int MCurrentSector3Time { get; set; }

        [DataMember(Name = "mCurrentTime")]
        public double MCurrentTime { get; set; }

        [DataMember(Name = "mEventTimeRemaining")]
        public int MEventTimeRemaining { get; set; }

        [DataMember(Name = "mFastestSector1Time")]
        public int MFastestSector1Time { get; set; }

        [DataMember(Name = "mFastestSector2Time")]
        public int MFastestSector2Time { get; set; }

        [DataMember(Name = "mFastestSector3Time")]
        public int MFastestSector3Time { get; set; }

        [DataMember(Name = "mLapInvalidated")]
        public bool MLapInvalidated { get; set; }

        [DataMember(Name = "mLastLapTime")]
        public int MLastLapTime { get; set; }

        [DataMember(Name = "mPersonalFastestLapTime")]
        public int MPersonalFastestLapTime { get; set; }

        [DataMember(Name = "mPersonalFastestSector1Time")]
        public int MPersonalFastestSector1Time { get; set; }

        [DataMember(Name = "mPersonalFastestSector2Time")]
        public int MPersonalFastestSector2Time { get; set; }

        [DataMember(Name = "mPersonalFastestSector3Time")]
        public int MPersonalFastestSector3Time { get; set; }

        [DataMember(Name = "mSplitTime")]
        public int MSplitTime { get; set; }

        [DataMember(Name = "mSplitTimeAhead")]
        public double MSplitTimeAhead { get; set; }

        [DataMember(Name = "mSplitTimeBehind")]
        public double MSplitTimeBehind { get; set; }

        [DataMember(Name = "mWorldFastestLapTime")]
        public double MWorldFastestLapTime { get; set; }

        [DataMember(Name = "mWorldFastestSector1Time")]
        public double MWorldFastestSector1Time { get; set; }

        [DataMember(Name = "mWorldFastestSector2Time")]
        public double MWorldFastestSector2Time { get; set; }

        [DataMember(Name = "mWorldFastestSector3Time")]
        public double MWorldFastestSector3Time { get; set; }
    }

    [DataContract]
    public class Flags
    {
        [DataMember(Name = "mHighestFlagColour")]
        public int MHighestFlagColour { get; set; }

        [DataMember(Name = "mHighestFlagReason")]
        public int MHighestFlagReason { get; set; }
    }

    [DataContract]
    public class PitInfo
    {
        [DataMember(Name = "mPitMode")]
        public int MPitMode { get; set; }

        [DataMember(Name = "mPitSchedule")]
        public int MPitSchedule { get; set; }
    }

    [DataContract]
    public class CarState
    {
        [DataMember(Name = "mAntiLockActive")]
        public bool MAntiLockActive { get; set; }

        [DataMember(Name = "mBoostActive")]
        public bool MBoostActive { get; set; }

        [DataMember(Name = "mBoostAmount")]
        public int MBoostAmount { get; set; }

        [DataMember(Name = "mBrake")]
        public int MBrake { get; set; }

        [DataMember(Name = "mCarFlags")]
        public int MCarFlags { get; set; }

        [DataMember(Name = "mClutch")]
        public int MClutch { get; set; }

        [DataMember(Name = "mFuelCapacity")]
        public int MFuelCapacity { get; set; }

        [DataMember(Name = "mFuelLevel")]
        public double MFuelLevel { get; set; }

        [DataMember(Name = "mFuelPressureKPa")]
        public double MFuelPressureKPa { get; set; }

        [DataMember(Name = "mGear")]
        public int MGear { get; set; }

        [DataMember(Name = "mLastOpponentCollisionIndex")]
        public int MLastOpponentCollisionIndex { get; set; }

        [DataMember(Name = "mLastOpponentCollisionMagnitude")]
        public int MLastOpponentCollisionMagnitude { get; set; }

        [DataMember(Name = "mMaxRPM")]
        public int MMaxRPM { get; set; }

        [DataMember(Name = "mNumGears")]
        public int MNumGears { get; set; }

        [DataMember(Name = "mOdometerKM")]
        public double MOdometerKM { get; set; }

        [DataMember(Name = "mOilTempCelsius")]
        public double MOilTempCelsius { get; set; }

        [DataMember(Name = "mRpm")]
        public double MRpm { get; set; }

        [DataMember(Name = "mSpeed")]
        public double MSpeed { get; set; }

        [DataMember(Name = "mSteering")]
        public double MSteering { get; set; }

        [DataMember(Name = "mThrottle")]
        public int MThrottle { get; set; }

        [DataMember(Name = "mWaterPressureKPa")]
        public double MWaterPressureKPa { get; set; }

        [DataMember(Name = "mWaterTempCelsius")]
        public double MWaterTempCelsius { get; set; }
    }

    [DataContract]
    public class MotionAndDeviceRelated
    {
        [DataMember(Name = "mAngularVelocity")]
        public IList<double> MAngularVelocity { get; set; }

        [DataMember(Name = "mExtentsCentre")]
        public IList<double> MExtentsCentre { get; set; }

        [DataMember(Name = "mLocalAcceleration")]
        public IList<double> MLocalAcceleration { get; set; }

        [DataMember(Name = "mLocalVelocity")]
        public IList<double> MLocalVelocity { get; set; }

        [DataMember(Name = "mOrientation")]
        public IList<double> MOrientation { get; set; }

        [DataMember(Name = "mWorldAcceleration")]
        public IList<double> MWorldAcceleration { get; set; }

        [DataMember(Name = "mWorldVelocity")]
        public IList<double> MWorldVelocity { get; set; }
    }

    [DataContract]
    public class WheelsAndTyres
    {
        [DataMember(Name = "mBrakeDamage")]
        public IList<int> MBrakeDamage { get; set; }

        [DataMember(Name = "mBrakeTempCelsius")]
        public IList<double> MBrakeTempCelsius { get; set; }

        [DataMember(Name = "mSuspensionDamage")]
        public IList<int> MSuspensionDamage { get; set; }

        [DataMember(Name = "mTerrain")]
        public IList<int> MTerrain { get; set; }

        [DataMember(Name = "mTyreCarcassTemp")]
        public IList<double> MTyreCarcassTemp { get; set; }

        [DataMember(Name = "mTyreFlags")]
        public IList<int> MTyreFlags { get; set; }

        [DataMember(Name = "mTyreGrip")]
        public IList<double> MTyreGrip { get; set; }

        [DataMember(Name = "mTyreHeightAboveGround")]
        public IList<double> MTyreHeightAboveGround { get; set; }

        [DataMember(Name = "mTyreInternalAirTemp")]
        public IList<double> MTyreInternalAirTemp { get; set; }

        [DataMember(Name = "mTyreLateralStiffness")]
        public IList<int> MTyreLateralStiffness { get; set; }

        [DataMember(Name = "mTyreLayerTemp")]
        public IList<double> MTyreLayerTemp { get; set; }

        [DataMember(Name = "mTyreRimTemp")]
        public IList<double> MTyreRimTemp { get; set; }

        [DataMember(Name = "mTyreRPS")]
        public IList<double> MTyreRPS { get; set; }

        [DataMember(Name = "mTyreSlipSpeed")]
        public IList<double> MTyreSlipSpeed { get; set; }

        [DataMember(Name = "mTyreTemp")]
        public IList<double> MTyreTemp { get; set; }

        [DataMember(Name = "mTyreTreadTemp")]
        public IList<double> MTyreTreadTemp { get; set; }

        [DataMember(Name = "mTyreWear")]
        public IList<double> MTyreWear { get; set; }

        [DataMember(Name = "mTyreY")]
        public IList<double> MTyreY { get; set; }
    }

    [DataContract]
    public class CarDamage
    {
        [DataMember(Name = "mAeroDamage")]
        public int MAeroDamage { get; set; }

        [DataMember(Name = "mCrashState")]
        public int MCrashState { get; set; }

        [DataMember(Name = "mEngineDamage")]
        public double MEngineDamage { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember(Name = "mAmbientTemperature")]
        public double MAmbientTemperature { get; set; }

        [DataMember(Name = "mCloudBrightness")]
        public double MCloudBrightness { get; set; }

        [DataMember(Name = "mRainDensity")]
        public int MRainDensity { get; set; }

        [DataMember(Name = "mTrackTemperature")]
        public double MTrackTemperature { get; set; }

        [DataMember(Name = "mWindDirectionX")]
        public double MWindDirectionX { get; set; }

        [DataMember(Name = "mWindDirectionY")]
        public double MWindDirectionY { get; set; }

        [DataMember(Name = "mWindSpeed")]
        public double MWindSpeed { get; set; }
    }

    [DataContract]
    public class ProjectCarsResponse
    {
        [DataMember(Name = "buildinfo")]
        public Buildinfo Buildinfo { get; set; }

        [DataMember(Name = "carDamage")]
        public CarDamage CarDamage { get; set; }

        [DataMember(Name = "carState")]
        public CarState CarState { get; set; }

        [DataMember(Name = "eventInformation")]
        public EventInformation EventInformation { get; set; }

        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }

        [DataMember(Name = "gameStates")]
        public GameStates GameStates { get; set; }

        [DataMember(Name = "motionAndDeviceRelated")]
        public MotionAndDeviceRelated MotionAndDeviceRelated { get; set; }

        [DataMember(Name = "participants")]
        public Participants Participants { get; set; }

        [DataMember(Name = "pitInfo")]
        public PitInfo PitInfo { get; set; }

        [DataMember(Name = "timings")]
        public Timings Timings { get; set; }

        [DataMember(Name = "unfilteredInput")]
        public UnfilteredInput UnfilteredInput { get; set; }

        [DataMember(Name = "vehicleInformation")]
        public VehicleInformation VehicleInformation { get; set; }

        [DataMember(Name = "weather")]
        public Weather Weather { get; set; }

        [DataMember(Name = "wheelsAndTyres")]
        public WheelsAndTyres WheelsAndTyres { get; set; }
    }
}