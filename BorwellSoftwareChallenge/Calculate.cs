
using System;

public class Calculate
    {
        //calculate the area of the room from the room width and height.
        public decimal calculateFloorArea(decimal floorWidth, decimal floorHeight)
        {
            return floorWidth * floorHeight;
        }

        //calculate the required paint needed to fully paint a wall.
        public decimal calculatePaint(int Doors, int Windows, int Coats, decimal wallSize)
        {
        // Divide by 10 then 4.54 as 10m2 is the coverage of a liter of paint
        //then divide by 4.54 as that's how many liters in a can
        decimal requiredPaint = (((wallSize - ((Doors * 2) + (Windows * 1.5m))) * Coats) / 10) / 4.54609188m; 
        return Math.Round(requiredPaint, 0, MidpointRounding.AwayFromZero);
        }

        //calculate the room volume from the room dimentions
        public decimal calculateRoomVolume(decimal roomWidth, decimal roomLength, decimal roomHeight)
        {
        return (roomWidth * roomLength) * roomHeight;
    }
    }
