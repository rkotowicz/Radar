using Radar.Model;
using Radar.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Radar.Controller
{
	internal class SimulatorController
	{
        readonly Simulator simulator;
		IPresenter presenter;
		bool simulationStarted = false;
        readonly Timer simulationTimer = new System.Windows.Forms.Timer();
		int simulationTimerInterval = 1000;
		readonly Form form;

        public bool SimulationStarted { get => simulationStarted; }

        public SimulatorController(Simulator simulator, IPresenter presenter, Form form)
		{
			this.simulator = simulator;
			this.presenter = presenter;
			this.form = form;
			this.simulationStarted = false;
			this.simulationTimer.Interval = simulationTimerInterval;
			this.simulationTimer.Tick += SimulationTimer_Tick;
		}
		public void panel_Paint(object? sender, PaintEventArgs e)
		{
			presenter.Draw(simulator, e.Graphics);
		}


		private void SimulationTimer_Tick(object? sender, EventArgs e)
		{
			if (!simulationStarted)
			{
				return;
			}

			simulator.SimulateNext();
			simulator.CheckDistanceAndGenerateEvents();
			presenter.Redraw();
			//StopSimulation();
			//presenter.ShowEvents(simulator);
			this.ReactForEvents();
		}

        private void ReactForEvents()
        {
			string eventsText = "";
			foreach (var ev in simulator.Events)
			{
				if(ev is Events.Collision evCol)
                {
					ReactForCollision(evCol);
                }
				if (ev is Events.Proximity evProx)
				{
					ReactForProximity(evProx);
				}
				eventsText += $"{ev}\r\n";
			}
			((RadarApp.MainForm)(form)).txbRadarLog.Text = eventsText;

		}

		private void ReactForCollision(Events.Collision evCol)
        {

        }

		private void ReactForProximity(Events.Proximity evProx)
		{
			StopSimulation();
			var res = MessageBox.Show($"{evProx}\nDo you want to change course ?", "Proximity warning !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			if(res.Equals(DialogResult.Yes))
            {
				// zmiana kursu
				MovableObject mo;
				SimulatedObject so;
				if(evProx.EventObjects.ObjA is MovableObject)
				{
					mo = evProx.EventObjects.ObjA as MovableObject;
					so = evProx.EventObjects.ObjB;
				}
				else
				{
					mo = evProx.EventObjects.ObjB as MovableObject;
					so = evProx.EventObjects.ObjA;
				}
				var vecToColision = so.Position - mo.Position;
				var vecToDst = mo.flightPlan.Section.EndPoint - mo.Position;
				vecToDst = vecToDst * so.Size / vecToDst.Length; // skalowanie do rozmiaru przeszkody
				var vecLeft = (vecToDst >> -60); // w lewo 
				var vecRight = (vecToDst >> 60); // w prawo
				var posLeft = mo.Position + vecLeft;
				var posRight = mo.Position + vecRight;
				var delLeft = so.Position - posLeft;  // nowe wektory po poprawce kursu do przeszkody
				var delRight = so.Position - posRight;
				if(delLeft.Length > delRight.Length)
				{
					mo.PrependNewFlightSection(posLeft);
				} else
				{
					mo.PrependNewFlightSection(posRight);
				}

			}
			StartSimulation();
		}



		public void StartSimulation()
		{
			simulationStarted = true;
			simulationTimer.Start();
		}
		public void StopSimulation()
		{
			simulationStarted = false;
			simulationTimer.Stop();
		}

		public void ChangeSimulationStep(int newStep)
		{
			simulator.SimulationStep = newStep;
		}


	}
}
