using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CombatLibrary.CombatMembers;
using CombatLibrary.Messages;
using Foundation.Messaging;
using WpfFoundation.Commands;
using WpfFoundation.Presenters;

namespace WpfRPGShell
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();

            CombatCommand = new ActionCommand(OnCombat);

            Presenter.Register(AppPresenters.Shell, new ContentControlPresenter(content));

            DataContext = this;
        }

        public ICommand CombatCommand { get; set; }

        private void OnCombat()
        {
            var players = new List<IPlayerCombatMember>
                              {
                                  new PlayerCombatMember(100, "JB")
                              };
            var monsters = new List<IMonsterCombatMember>
                               {
                                   new MonsterCombatMember(50, "Monster")
                               };

            var message = new StartCombatMessage(players, monsters);
            MessageBroker.Send(message);
        }
    }
}