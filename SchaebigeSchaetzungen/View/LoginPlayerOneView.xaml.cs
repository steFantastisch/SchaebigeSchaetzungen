
using System.Windows;
using System.Windows.Controls;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaktionslogik für MainPlayerLoginView.xaml
    /// </summary>
    public partial class LoginPlayerOneView : UserControl
    {
        public LoginPlayerOneView()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Das Spiel „Schäbige Schätzungen“ ist ein Ratespiel, bei dem der Spieler die Anzahl der Aufrufe eines zufällig ausgewählten YouTube-Videos erraten muss. Der Spieler hat die Möglichkeit, das Spiel im Singleplayer-Modus oder im 2-Spieler-Modus zu spielen.\r\nIm Singleplayer-Modus wird der Spieler mit 5 zufällig ausgewählten YouTube-Videos konfrontiert. Der Spieler hat die Aufgabe, die Anzahl der Aufrufe des Videos zu erraten. Wenn der Spieler nicht sicher ist, kann er auf den \"Hint\"-Button klicken, um weitere Informationen zu erhalten. Der Hinweis zeigt die Anzahl der Kommentare und die Anzahl der Likes an. Nachdem der Spieler seine Schätzung abgegeben hat, wird die tatsächliche Anzahl der Aufrufe angezeigt und der Spieler erhält Punkte basierend darauf, wie nah er an der tatsächlichen Anzahl der Aufrufe liegt.\r\nIm 2-Spieler-Modus spielen zwei Spieler gegeneinander. Jeder Spieler wird ebenfalls mit 5 zufällig ausgewählten YouTube-Videos konfrontiert und gibt seine Schätzung ab. Der Spieler, der am Ende der Runde mehr Punkte hat, gewinnt das Spiel.\r\nFalls ein Video nicht verfügbar sein sollte, kann der Spieler den Video N/A Button drücken um direkt das nächste Video zu laden, ohne das eine Spielrunde übersprungen wird. Gründe für die nicht Verfügbarkeit eines Videos sind zum Beispiel Altersbeschränkungen oder Länderbeschränkungen [0257af8a].\r\n", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
