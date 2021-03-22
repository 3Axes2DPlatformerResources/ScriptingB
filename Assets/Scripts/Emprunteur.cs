public class Emprunteur : Client {
      private int montantEmprunt;

      public Emprunteur(string prenom, string nom, int age, int montantEmprunt)
          : base(prenom, nom, age) {
          this.montantEmprunt = montantEmprunt;
      }
}