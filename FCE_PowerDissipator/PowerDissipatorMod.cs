public class PowerDissipatorMod : FortressCraftMod
{
    public ushort MyModMachineType = ModManager.mModMappings.CubesByKey["nailgunster2.PowerDissipator"].CubeType;

    public override ModRegistrationData Register()
    {
        ModRegistrationData modRegistrationData = new ModRegistrationData();
        modRegistrationData.RegisterEntityHandler("nailgunster2.PowerDissipator");
        return modRegistrationData;
    }

    public override ModCreateSegmentEntityResults CreateSegmentEntity(ModCreateSegmentEntityParameters parameters)
    {
        ModCreateSegmentEntityResults result = new ModCreateSegmentEntityResults();

        //Assumes that all value entries are handled by the same machine!  
        if (parameters.Cube == MyModMachineType)
        {
            result.Entity = new PowerDissipatorMachine(parameters);
        }
        return result;
    }
}
