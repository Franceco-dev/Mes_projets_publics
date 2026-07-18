// je vais pas utiliser de la poo
import java.util.Scanner;

class Methode {
    public static void main(String[] args) {


        Scanner sc = new Scanner(System.in);

        System.out.println("Essayez de deviner mon nombe !!! ");

        Calcul(sc.nextInt());




    }

    public static void Calcul(int NombreChercher){
        int NombreBase = 4;

        if(NombreChercher == NombreBase){
            System.out.println("Bravo c'est la bonne réponse !!!! ");
        }

        else if (NombreChercher > NombreBase && NombreChercher % 2 == 0){
            System.out.println("Votre chiffre est trop grand mais il est pair");
        }

        else if(NombreChercher > NombreBase && NombreChercher % 2 != 0){
            System.out.println("Votre chiffre est trop grand et impair");
        }

        else if(NombreChercher < NombreBase && NombreChercher % 2 != 0){
            System.out.println("Votre chiffre est trop petit et impair");

        }

        else{
            System.out.println("Votre chiffre est trop petit mais il est pair");
        }


    }



}

