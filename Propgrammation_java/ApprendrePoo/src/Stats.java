import java.util.Scanner;

public class Stats {
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);

        while (true){
            boolean VoirClasse = false;

            System.out.println("Bonjour, voulez-vous voir les différentes classes et personnages disponibles ? Tapez oui ou non ! ");
            String confirmationClasse = sc.nextLine();

            if (confirmationClasse.equalsIgnoreCase("oui") ){
                VoirClasse = true;
                System.out.println("VILLAGEOIS MÉTIER -------> pêcheur, forgeron, cartographe");
                System.out.println("PV ---------> 20");
                System.out.println("===============================================================");
                System.out.println("GUERRIER MÉTIER ---------> fantassin, cavalier, garde");
                System.out.println("PV ---------> 30");
            }
            else if (confirmationClasse.equalsIgnoreCase("non")){
                System.out.println("Ce serait quand même bien de checker ;)");
                break;
            }
            else{
                System.out.println("...");
                break;
            }

            System.out.println("Choisissez à présent votre classe !");
            String choixduJoueur = sc.nextLine();

            if (choixduJoueur.equalsIgnoreCase("Villageois")){
                System.out.println("Choisissez un nom pour votre villageois ! ");
                String NomVillageois = sc.nextLine();
                System.out.println(NomVillageois + ", " + NomVillageois + " bien sûr ! Maintenant, choisissez votre métier : ");
                String choixClasse = sc.nextLine();

                if (choixClasse.equalsIgnoreCase("pêcheur")){
                    villageois pecheur = new villageois(choixClasse, NomVillageois, 20);
                    pecheur.MetieretStats();
                }
                else if (choixClasse.equalsIgnoreCase("forgeron")){
                    villageois forgeron = new villageois(choixClasse, NomVillageois, 20);
                    forgeron.MetieretStats();
                }
                else if(choixClasse.equalsIgnoreCase("cartographe")){
                    villageois cartographe = new villageois(choixClasse, NomVillageois, 20);
                    cartographe.MetieretStats();
                }
                else{
                    System.out.println("Il semble qu'il manque quelque chose.");
                }
            }

            else if(choixduJoueur.equalsIgnoreCase("Guerrier")){
                System.out.println("Choisissez un nom pour votre guerrier ! ");
                String NomGuerrier = sc.nextLine();
                System.out.println(NomGuerrier + "... Intéressant ! Et quel sera le métier de " + NomGuerrier + " ?");
                String choixMetier = sc.nextLine();

                if (choixMetier.equalsIgnoreCase("fantassin")){
                    guerrier fantassin = new guerrier(choixMetier, NomGuerrier, 30);
                    fantassin.guerrierStats();
                }
                else if(choixMetier.equalsIgnoreCase("cavalier")){
                    guerrier cavalier = new guerrier(choixMetier, NomGuerrier, 30);
                    cavalier.guerrierStats();
                }
                else if(choixMetier.equalsIgnoreCase("garde")){
                    guerrier garde = new guerrier(choixMetier, NomGuerrier, 30);
                    guerrier.guerrierStats();
                }
                else{
                    System.out.println("Il semble qu'il manque quelque chose.");
                }
            }
            else{
                System.out.println("Veuillez svp configurer votre personnage.");
            }
        }
    }
}


