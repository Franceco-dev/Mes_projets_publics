public class guerrier {

    public String metier;
    public String nom;
    public int vie;

    public guerrier(String metierAttribuer, String nomAttribuer, int pointDevie){
        this.metier = metierAttribuer;
        this.nom = nomAttribuer;
        this.vie = pointDevie;
    }

    public void guerrierStats(){
        System.out.println("Votre guerrier se nomme " + nom + ", son métier est " + metier + " et il possède " + vie + " points de vie.");
    }
}
