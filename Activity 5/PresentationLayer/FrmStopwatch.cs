/*
 * Shawn Kripner
 * CST-250
 * 4/20/2026
 * Whack-A-Mole
 * Activity 5
 * */

namespace WhackAMole
{
    public partial class FrmStopwatch : Form
    {
        public FrmStopwatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click Event Handler for btnStart
        /// Starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start the timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click Event Handler for btnStop
        /// Stops the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop the timer
            tmrStopwatch.Stop();
        }

    }
}
