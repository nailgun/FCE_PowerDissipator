using System;
using UnityEngine;

public class PowerDissipatorMachine : MachineEntity, PowerConsumerInterface
{
    float totalPower = 0;
    float lowFreqTimer = 0;
    float totalTime = 0;
    
    public PowerDissipatorMachine(ModCreateSegmentEntityParameters parameters)
    : base(parameters)
    {
        mbNeedsLowFrequencyUpdate = true;
    }

    public override void LowFrequencyUpdate()
    {
        base.LowFrequencyUpdate();
        if (totalPower > 0)
        {
            lowFreqTimer += LowFrequencyThread.mrPreviousUpdateTimeStep;
        }
    }

    public override string GetPopupText()
    {
        if (Input.GetButtonDown("Extract"))
        {
            totalPower = 0;
            lowFreqTimer = 0;
            totalTime = 0;
        }

        string header = "Power Dissipator\n";

        if (totalPower > 0)
        {
            float pps = 0;
            if (totalTime > 0)
            {
                pps = totalPower / totalTime;
            }

            return header +
                "Dissipated " + Math.Round(totalPower) + " power\n" +
                "Time " + Math.Round(lowFreqTimer) + "s\n" +
                "PPS " + Math.Round(pps, 2) + "\n" +
                "\nQ to reset";
        }
        else
        {
            return header +
                "Waiting for power...";
        }
    }

    bool PowerConsumerInterface.DeliverPower(float amount)
    {
        if (lowFreqTimer <= 0)
        {
            lowFreqTimer = LowFrequencyThread.mrPreviousUpdateTimeStep;
        }

        totalTime = lowFreqTimer;
        totalPower += amount;
        return true;
    }

    float PowerConsumerInterface.GetMaximumDeliveryRate()
    {
        return float.MaxValue;
    }

    float PowerConsumerInterface.GetMaxPower()
    {
        return float.MaxValue;
    }

    float PowerConsumerInterface.GetRemainingPowerCapacity()
    {
        return float.MaxValue;
    }

    bool PowerConsumerInterface.WantsPowerFromEntity(SegmentEntity entity)
    {
        return true;
    }
}
