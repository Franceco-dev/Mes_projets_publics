while True:
    mode = input("Bonjour je suis votre super calculateur python que voulez vous que je calcule ")

    if "addition" in mode:
        addition1 = int(input("Votre premier nombre svp "))
        addition2 = int(input("Votre deuxième nombre svp "))
        print("Somme =", addition1 + addition2)

    elif "soustraction" in mode:
        soustraction1 = int(input("Votre premier nombre svp "))
        soustraction2 = int(input("Votre deuxième nombre svp "))
        print("Difference =", soustraction1 - soustraction2)

    elif "multiplication" in mode:
        BotQuestion = input("voulez vous une table ou un calcul précis ")
        
        if "table" in BotQuestion:
            BotMult = int(input("je vous calcul jusqu'en table de "))
            compteur = 0
            multiplication = int(input("Votre nombre svp "))
            
            for i in range(1, BotMult + 1):
                compteur += 1
                print("Produit", compteur, "=", multiplication * i)
        
        else:
            Multiplication1 = int(input("Votre premier nombre svp "))
            Multiplication2 = int(input("Votre deuxième nombre svp "))
            print("Produit =", Multiplication1 * Multiplication2)

    elif "division" in mode:
        division1 = int(input("Votre premier nombre svp "))
        division2 = int(input("Votre deuxième nombre svp "))
        print("Quotient =", division1 / division2)
        
    elif "stop" in mode:
        print("Un plaisir chère client")
        break
    
    elif "sert" in mode:
        print("je peux additionner, soustraire, multiplier et diviser vos calculs")
        
    elif "comment" in mode:
        print("dites, soustraction, multiplication, addition, division je vous ferai le calcul")
        
    else:
        print("...")