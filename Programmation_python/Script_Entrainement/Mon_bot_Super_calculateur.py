while True:
    mode = input("Bonjour, je suis votre super calculateur Python. Que voulez-vous que je calcule ? ")

    if "addition" in mode:
        addition1 = int(input("Votre premier nombre svp : "))
        addition2 = int(input("Votre deuxième nombre svp : "))
        print("Somme =", addition1 + addition2)

    elif "soustraction" in mode:
        soustraction1 = int(input("Votre premier nombre svp : "))
        soustraction2 = int(input("Votre deuxième nombre svp : "))
        print("Différence =", soustraction1 - soustraction2)

    elif "multiplication" in mode:
        BotQuestion = input("Voulez-vous une table ou un calcul précis ? ")
        
        if "table" in BotQuestion:
            BotMult = int(input("Je vous calcule jusqu'à la table de : "))
            compteur = 0
            multiplication = int(input("Votre nombre svp : "))
            
            for i in range(1, BotMult + 1):
                compteur += 1
                print("Produit", compteur, "=", multiplication * i)
        
        else:
            Multiplication1 = int(input("Votre premier nombre svp : "))
            Multiplication2 = int(input("Votre deuxième nombre svp : "))
            print("Produit =", Multiplication1 * Multiplication2)

    elif "division" in mode:
        division1 = int(input("Votre premier nombre svp : "))
        division2 = int(input("Votre deuxième nombre svp : "))
        print("Quotient =", division1 / division2)
        
    elif "stop" in mode:
        print("Au revoir ! Ce fut un plaisir, cher client.")
        break
    
    elif "sert" in mode:
        print("Je peux additionner, soustraire, multiplier et diviser vos calculs.")
        
    elif "comment" in mode:
        print("Dites 'addition', 'soustraction', 'multiplication' ou 'division' et je ferai le calcul.")
        
    else:
        print("...")
