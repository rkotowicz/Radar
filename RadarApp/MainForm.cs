using Radar.Controller;
using Radar.Model;
using Radar.Presenter;
using System.Linq;

namespace RadarApp
{
	public partial class MainForm : Form
	{
		SimulatorController simulatorController;
		Simulator simulator;
		IPresenter presenter;
		public MainForm()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			simulator = new Radar.Model.Simulator();
			presenter = new GraphicalPresenter(graphicsPanel1, Simulator.MaxX, Simulator.MaxY, Simulator.MaxZ);
			simulatorController = new SimulatorController(simulator, presenter, this);
			graphicsPanel1.Paint += simulatorController.panel_Paint;
			simulatorController.StartSimulation();
		}

        private void btnRunPause_Click(object sender, EventArgs e)
        {
			if(simulatorController.SimulationStarted)
            {
				simulatorController.StopSimulation();
				btnRunPause.UseMnemonic = true;
				
				btnRunPause.Text = "UN&PAUSE";
            } else
            {
				simulatorController.StartSimulation();
				btnRunPause.UseMnemonic = true;
				btnRunPause.Text = "&PAUSE";
			}
		}
		private const uint WM_UPDATEUISTATE = 0x0128;
		private const uint WM_QUERYUISTATE = 0x0129;
		private const uint UIS_CLEAR = 2;
		private const uint UISF_HIDEACCEL = 0x2;

		private void ClearHideAccel()
		{
			UIntPtr wParam = (UIntPtr)((UISF_HIDEACCEL << 16) | UIS_CLEAR);
			NativeMethods.SendMessage(this.Handle, WM_UPDATEUISTATE, wParam, IntPtr.Zero);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			ClearHideAccel();
		}

	}

	internal class NativeMethods
	{
		[System.Runtime.InteropServices.DllImport("User32", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);
	}
}