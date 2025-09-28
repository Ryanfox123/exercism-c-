class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    public int speed;
    int battery = 100;
    public int batteryDrain;
    int meters;


    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }
    public bool BatteryDrained()
    {
        return battery <= 0 || battery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return meters;
    }

    public void Drive()
    {
        if (battery <= 0 || battery < batteryDrain)
        {
            return;
        }
            battery -= batteryDrain;
            meters += speed;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < this.distance)
        {
            if (car.BatteryDrained())
            {
                return false;
            }
            car.Drive();
        }
        return true;
    }
}
