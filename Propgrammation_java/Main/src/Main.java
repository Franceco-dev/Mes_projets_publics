import java.util.Scanner;

public class Main{ // attention ce code n'utilise pas encore la poo il y aura peut etre d'autre code avec poo mais là je débute
    public static void main(String[] args){

        Scanner sc = new Scanner(System.in);

        while (true){
            System.out.print("Bonjour me revoilà sur java quelle plaisir de vous retrouver que voulez vous que je vous fasse ??? ");
            String Mode = sc.nextLine();

            if (Mode.contains("Addition")){
                System.out.println("Votre premier nombre svp !! ");
                int Nombre1 = sc.nextInt();
                System.out.println("Votre deuxième nombre svp !! ");
                int Nombre2 = sc.nextInt();
                sc.nextLine();

                System.out.println("La somme total de " + Nombre1 + " + " + Nombre2 + " = " + (Nombre1 + Nombre2));


            }

            else if(Mode.contains("Soustraction")){
                System.out.println("Votre premier nombre svp ");
                int Soustraction1 = sc.nextInt(); // desolé de l'incoherence des variables ^-^
                System.out.println("Votre deuxième nombre svp ");
                int Soustraction2 = sc.nextInt();
                sc.nextLine();

                System.out.println("La difference entre " + Soustraction1 + " - " + Soustraction2 + " = " + (Soustraction1 - Soustraction2));



            }

            else if(Mode.contains("Division")){
                System.out.println("Votre Divident svp !! ");
                int Divident1 = sc.nextInt();
                System.out.println(" Votre deuxième nombre svp !!! ");
                int Diviseur2 = sc.nextInt();
                sc.nextLine();



                if(Diviseur2 == 0){
                    System.out.println("Impossible de faire ça cette fois j'ai prévu le truc heheh");

                }
                else{
                    System.out.println("Le quotient de la division " + Divident1 + " / " + Diviseur2 + " = " + (Divident1 / Diviseur2));
                }

            }

            else if(Mode.contains("Multiplication")){
                System.out.println("J'ai deux façon de faire sois en tabulation ou en calcul simple choisissez laquelle !!! ");
                String BotMult = sc.nextLine(); // j'avais pas d'idée non plus là

                if(BotMult.contains("tabulation")){
                    System.out.println("Choisissez votre nomre svp !! ");
                    int Tabulation = sc.nextInt();
                    sc.nextLine();
                    int compteur = 0;

                    for(int i = 0; i <= Tabulation; i++){
                        System.out.println("Table " + (compteur += 1) + " = " + (Tabulation * i));
                    }

                }
                else if(BotMult.contains("calcul simple")){
                    System.out.println("Votre premier nombre svp !!! ");
                    int Multiplication1 = sc.nextInt();
                    System.out.println("Votre deuxième nombre svp !!! ");
                    int Multiplication2 = sc.nextInt();
                    sc.nextLine();

                    System.out.println(" le produit de " + Multiplication1 + " * " + Multiplication2 + " = " + (Multiplication1 * Multiplication2));
                }
            }

            else if(Mode.contains("quoi ")){
                System.out.println("Je peux additionner, soustraire, Diviser, Multiplier pour le moment");

            }



            else if(Mode.contains("Stop")){
                System.out.println("Au revoir !!!");
                break;
            }
        }




    }
}
