import java.util.Scanner;

public class Main { // Attention, je n'utilise pas encore de POO sur ce script car c'était un de mes premiers vrais scripts java.
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        while (true) {
            System.out.print("Bonjour ! Me revoilà sur Java, quel plaisir de vous retrouver. Que voulez-vous que je fasse ? ");
            String Mode = sc.nextLine();

            if (Mode.contains("Addition")) {
                System.out.println("Votre premier nombre svp ! ");
                int Nombre1 = sc.nextInt();
                System.out.println("Votre deuxième nombre svp ! ");
                int Nombre2 = sc.nextInt();
                sc.nextLine();

                System.out.println("La somme totale de " + Nombre1 + " + " + Nombre2 + " = " + (Nombre1 + Nombre2));
            }

            else if (Mode.contains("Soustraction")) {
                System.out.println("Votre premier nombre svp ");
                int Soustraction1 = sc.nextInt(); // Désolé pour l'incohérence des variables ^-^
                System.out.println("Votre deuxième nombre svp ");
                int Soustraction2 = sc.nextInt();
                sc.nextLine();

                System.out.println("La différence entre " + Soustraction1 + " - " + Soustraction2 + " = " + (Soustraction1 - Soustraction2));
            }

            else if (Mode.contains("Division")) {
                System.out.println("Votre dividende svp ! ");
                int Divident1 = sc.nextInt();
                System.out.println("Votre deuxième nombre svp ! ");
                int Diviseur2 = sc.nextInt();
                sc.nextLine();

                if (Diviseur2 == 0) {
                    System.out.println("Impossible de faire ça, cette fois j'ai prévu le truc heheh");
                } else {
                    System.out.println("Le quotient de la division " + Divident1 + " / " + Diviseur2 + " = " + (Divident1 / Diviseur2));
                }
            }

            else if (Mode.contains("Multiplication")) {
                System.out.println("J'ai deux façons de faire, soit en tabulation, soit en calcul simple. Choisissez laquelle ! ");
                String BotMult = sc.nextLine(); // Je n'avais pas d'idée non plus ici

                if (BotMult.contains("tabulation")) {
                    System.out.println("Choisissez votre nombre svp ! ");
                    int Tabulation = sc.nextInt();
                    sc.nextLine();
                    int compteur = 0;

                    for (int i = 0; i <= Tabulation; i++) {
                        System.out.println("Table " + (compteur += 1) + " = " + (Tabulation * i));
                    }
                } 
                else if (BotMult.contains("calcul simple")) {
                    System.out.println("Votre premier nombre svp ! ");
                    int Multiplication1 = sc.nextInt();
                    System.out.println("Votre deuxième nombre svp ! ");
                    int Multiplication2 = sc.nextInt();
                    sc.nextLine();

                    System.out.println("Le produit de " + Multiplication1 + " * " + Multiplication2 + " = " + (Multiplication1 * Multiplication2));
                }
            }

            else if (Mode.contains("quoi ")) {
                System.out.println("Je peux additionner, soustraire, diviser ou multiplier pour le moment.");
            }

            else if (Mode.contains("Stop")) {
                System.out.println("Au revoir !");
                break;
            }
        }
    }
}
