public class Client {
    // Données
    private string prenom;
    private string nom;
    private int age;
    public int solde;
    private int nbOperations;

    public Client(string prenom, string nom, int age) {
        this.prenom = prenom;
        this.nom = nom;
        this.age = age;
        solde = 0;
    }

    // Méthodes
    public void AjouterAuSolde(int montant) {
        solde = solde + montant;
        nbOperations++;
    }
}