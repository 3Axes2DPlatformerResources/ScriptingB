public class Main {
        public void main() {
                Client client = new Client("Alice", "Jacquelin", 20);
                Client client2 = new Client("Bob", "Dupont", 20);
                client.AjouterAuSolde(2);
                client2.AjouterAuSolde(5);

                Emprunteur emprunteur = new Emprunteur("Alice", "Jacquelin", 20, 20000);
                emprunteur.AjouterAuSolde(20);
        }
}