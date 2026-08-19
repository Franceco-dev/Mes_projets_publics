

public class villageois{

    public String metier;
    public String nom;
    public int pointDevie;

    public villageois(String metierAttribuer ,String nomAttribuer, int pointDevieDonner){
        this.metier = metierAttribuer;
        this.nom = nomAttribuer;
        this.pointDevie = pointDevieDonner;

    }

    public void MetieretStats(){
        System.out.println("votre villageois se nomme " + nom + " son metier est " + metier + " et il possède " + pointDevie + " points de vie");
    }

}
