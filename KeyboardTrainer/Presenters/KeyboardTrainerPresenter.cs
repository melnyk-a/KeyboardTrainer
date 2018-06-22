using KeyboardTrainer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.Presenters
{
    internal sealed class KeyboardTrainerPresenter : IPresenter
    {
        private readonly IKeyboardTrainerView view;
        public KeyboardTrainerPresenter(IKeyboardTrainerView view)
        {
            this.view = view;
        }
        public void Run()
        {
            view.Show();
        }
    }
}