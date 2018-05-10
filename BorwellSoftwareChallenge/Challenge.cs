using System;
using System.Windows.Forms;

namespace BorewellSoftwareChallenge
{
    public partial class Challenge : Form
    {
        //Initialise the Calculate class
        Calculate clc = new Calculate();

        public Challenge()
        {
            InitializeComponent();
        }

        private void Challenge_Load(object sender, EventArgs e)
        {
            resetWallControls();

            foreach(Control c in gbRoomDimentions.Controls)
            {
                if(c is NumericUpDown)
                {
                    c.TextChanged += new EventHandler(calculateFloorArea);
                    c.TextChanged += new EventHandler(calculateVolume);
                }
            }

            foreach(Control c in gbWallDimentions.Controls)
            {
                if (c is NumericUpDown)
                {
                    c.TextChanged += new EventHandler(calculatePaint);
                }
            }
        }

        //Calculate the area of the floor
        private void calculateFloorArea(object sender, EventArgs e)
        {
            if(nudFloorWidth.Value !=0 && nudFloorLength.Value != 0)
            {
                decimal floorWidth = clc.calculateFloorArea(nudFloorWidth.Value, nudFloorLength.Value);
                lblFloorArea.Text = "Total Area of floor: " + floorWidth + "m²";
            }
            else
            {
                lblFloorArea.Text = "Please enter valid values for the area of the floor";
            }
        }

        //calculate paint required for walls depending on how many walls the user has selected
        private void calculatePaint(object sender, EventArgs e)
        {
            switch (nudWallAmount.Value)
            {
                case 1:
                    if (nudWallHeight1.Value != 0 && nudWallWidth1.Value != 0)
                    {
                        decimal totWallArea = nudWallHeight1.Value * nudWallWidth1.Value;
                        decimal paintRequired = clc.calculatePaint(Convert.ToInt32(nudDoors.Value), Convert.ToInt32(nudWindows.Value), Convert.ToInt32(nudCoats.Value), totWallArea);
                        lblPaintRequired.Text = "Total Paint Required: " + paintRequired + " cans of paint required";
                    }
                    else
                    {
                        lblPaintRequired.Text = "Please enter valid values to calculate paint";
                    }
                    break;
                case 2:
                    if (nudWallHeight1.Value != 0 && nudWallWidth1.Value != 0 && nudWallHeight2.Value != 0 && nudWallWidth2.Value != 0)
                    {
                        decimal totWallArea = (nudWallHeight1.Value * nudWallWidth1.Value) + (nudWallHeight2.Value * nudWallWidth2.Value);
                        decimal paintRequired = clc.calculatePaint(Convert.ToInt32(nudDoors.Value), Convert.ToInt32(nudWindows.Value), Convert.ToInt32(nudCoats.Value), totWallArea);
                        lblPaintRequired.Text = "Total Paint Required: " + paintRequired + " cans of paint required";
                    }
                    else
                    {
                        lblPaintRequired.Text = "Please enter valid values to calculate paint";
                    }
                    break;
                case 3:
                    if (nudWallHeight1.Value != 0 && nudWallWidth1.Value != 0 && nudWallHeight2.Value != 0 && nudWallWidth2.Value != 0 || nudWallHeight3.Value != 0 && nudWallHeight4.Value != 0)
                    {
                        decimal totWallArea = (nudWallHeight1.Value * nudWallWidth1.Value) + (nudWallHeight2.Value * nudWallWidth2.Value) + (nudWallHeight3.Value * nudWallWidth3.Value);
                        decimal paintRequired = clc.calculatePaint(Convert.ToInt32(nudDoors.Value), Convert.ToInt32(nudWindows.Value), Convert.ToInt32(nudCoats.Value), totWallArea);
                        lblPaintRequired.Text = "Total Paint Required: " + paintRequired + " cans of paint required";
                    }
                    else
                    {
                        lblPaintRequired.Text = "Please enter valid values to calculate paint";
                    }
                    break;
                case 4:
                    if (nudWallHeight1.Value != 0 && nudWallWidth1.Value != 0 && nudWallHeight2.Value != 0 && nudWallWidth2.Value != 0 && nudWallHeight3.Value != 0 && nudWallHeight4.Value != 0)
                    {
                        decimal totWallArea = (nudWallHeight1.Value * nudWallWidth1.Value) + (nudWallHeight2.Value * nudWallWidth2.Value) + (nudWallHeight3.Value * nudWallWidth3.Value) + (nudWallHeight4.Value * nudWallWidth4.Value);
                        decimal paintRequired = clc.calculatePaint(Convert.ToInt32(nudDoors.Value), Convert.ToInt32(nudWindows.Value), Convert.ToInt32(nudCoats.Value), totWallArea);
                        lblPaintRequired.Text = "Total Paint Required: " + paintRequired + " cans of paint required";
                    }
                    else
                    {
                        lblPaintRequired.Text = "Please enter valid values to calculate paint";
                    }
                    break;
            }
        }

//calculate the volume of the room
private void calculateVolume(object sender, EventArgs e)
        {
            if(nudRoomWidth.Value != 0 && nudRoomLength.Value != 0 && nudRoomHeight.Value != 0)
            {
                decimal roomVolume = clc.calculateRoomVolume(nudRoomWidth.Value, nudRoomLength.Value, nudRoomHeight.Value);
                lblRoomVolume.Text = "Total Room Volume: " + roomVolume + "m³";
            }
            else
            {
                lblRoomVolume.Text = "Please enter valid values for the volume of the room";
            }
        }

        private void resetWallControls()
        {
            nudWallHeight2.Enabled = false;
            nudWallWidth2.Enabled = false;
            nudWallHeight3.Enabled = false;
            nudWallWidth3.Enabled = false;
            nudWallHeight4.Enabled = false;
            nudWallWidth4.Enabled = false;
        }

        private void nudWallAmount_ValueChanged(object sender, EventArgs e)
        {
            //enable/disable controls depening on how many walls the user selects
            resetWallControls();
            switch (nudWallAmount.Value)
            {
                case 2:
                    nudWallHeight2.Enabled = true;
                    nudWallWidth2.Enabled = true;
                    break;
                case 3:
                    nudWallHeight2.Enabled = true;
                    nudWallWidth2.Enabled = true;
                    nudWallHeight3.Enabled = true;
                    nudWallWidth3.Enabled = true;
                    break;
                case 4:
                    nudWallHeight2.Enabled = true;
                    nudWallWidth2.Enabled = true;
                    nudWallHeight3.Enabled = true;
                    nudWallWidth3.Enabled = true;
                    nudWallHeight4.Enabled = true;
                    nudWallWidth4.Enabled = true;
                    break;
            }
        }
    }
}
