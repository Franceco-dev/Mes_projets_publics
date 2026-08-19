import java.util.Scanner;

public class Stats {
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);

        while (true){
            boolean VoireClasse = false;

            System.out.println("Bonjour, voulez vous voire les differentes classes et personnages disponible ??? tapez oui ou non !!!! ");
            String confirmationClasse = sc.nextLine();

            if (confirmationClasse.equalsIgnoreCase("oui") ){
                VoireClasse = true;
                System.out.println("VILLAGEOIS METIER -------> pêcheur, forgeron, cartographe");
                System.out.println("PV ---------> 20");
                System.out.println("===============================================================");
                System.out.println("GUERRIER METIER ---------> fantassin, cavalier, garde");
                System.out.println("PV ---------> 30");
            }
            else if (confirmationClasse.equalsIgnoreCase("Non")){
                System.out.println("Ce serai quand même bien de checker ;)");
                break;
            }
            else{
                System.out.println("...");
                break;
            }

            System.out.println("Choisissez à présent votre classe !!!!!!!");
            String choixduJoueur = sc.nextLine();

            if (choixduJoueur.equalsIgnoreCase("Villageois")){
                System.out.println("Choisissez un nom à votre villageois !!!! ");
                String NomVillageois = sc.nextLine();
                System.out.println(NomVillageois + ", " + NomVillageois + " bien sûr maintenant choisissez votre metier ");
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
                    System.out.println("Il semble que il manque quelque chose ");
                }
            }

            else if(choixduJoueur.equalsIgnoreCase("Guerrier")){
                System.out.println("Choississez un nom à votre guerrier !!!! ");
                String NomGuerrier = sc.nextLine();
                System.out.println(NomGuerrier + " interressant et quelle sera le metier de " + NomGuerrier);
                String choixMetier = sc.nextLine();

                if (choixMetier.equalsIgnoreCase("fantassin")){
                    guerrier fantassin = new guerrier(choixMetier, NomGuerrier  , 30);
                    fantassin.guerrierStats();
                }

                else if(choixMetier.equalsIgnoreCase("cavalier")){
                    guerrier cavalier = new guerrier(choixMetier, NomGuerrier, 30);
                    cavalier.guerrierStats();
                }

                else if(choixMetier.equalsIgnoreCase("garde")){
                    guerrier garde = new guerrier(choixMetier, NomGuerrier, 30);
                    garde.guerrierStats();
                }
                else{
                    System.out.println("Il semble qu'il manque quelque chose");
                }


            }
            else{
                System.out.println("Veuillez svp remplir votre personnage");
            }

        }
    }
}


