using System;

namespace ShoeShop
{
    class Startup
    {
        //Magazinul cu pantofi
        //Descriere: Într-un magazin care vinde pantofi există un singur raft pe care sunt puse toate cutiile de
        //pantofi, una după alta, în ordine crescătoare a numărului de pe pantofi(de ex. 36, 37, 42, etc.). Fiecare
        //pantof are o mărime, o culoare și un preț.
        //Ne trebuie un container pentru: a reține pantofii de pe raft
        //Funcționalități:
        // 1. Adăugați pantofi noi la raft(când vânzătorul aduce pantofi noi)
        // 2. Verificați dacă oferta de pantofi este echilibrată(oferta de pantofi se consideră echilibrată dacă
        //    diferența maximă dintre stocurile pentru fiecare mărime existentă este 3.
        // 3. O clientă mai specială, Marisol, are o metodă interesantă de a cumpăra pantofi. Alege în mod
        //    aleator 2 poziții de pe raft, și cere să-i fie aduse toate perechile de pantofi dintre cele 2 poziții
        //    (aceste elemente sunt eliminate de pe raft). Clienta parcurge șirul de pantofi și dintre acele
        //    perechi care corespund cu mărimea ei, alege fiecare a 2-a pereche de pantofi.Restul pantofilor
        //    sunt puși înapoi pe raft. Afișați lista pantofilor cumpărați de clienta, lista pantofilor rămași pe
        //    raft după plecarea ei și prețul plătit de ea.

        //Exemple:
        // Să presupunem că la un moment dat avem următoarele pantofi:
        //o(34, negru, 25)
        //o(34, verde, 50)
        //o(34, gri, 32)
        //o(35, negru, 35)
        //o(35, negru, 10)
        //o(35, rosu, 71)
        //o(36, gri, 13)
        //o(36, verde, 43)
        //o(36, negru, 39)
        //o(36, negru, 32)
        //o(37, negru, 15)
        //o(37, verde, 43)
        //o(38, negru, 33)
        //o(38, negru, 27)
        // Oferta de pantofi este echilibrată: avem 3 pantofi 34, 3 pantofi 35, 4 pantofi 36, 2 pantofi 37, 2
        //pantofi 38. Diferența maximă 4-2 = 2.
        // Dacă Marisol poartă 36 și alege pozițiile 6, 12, ea va primi pantofii:
        //o(36, gri, 13)
        //o(36, verde, 43)
        //o(36, negru, 39)
        //o(36, negru, 32)
        //o(37, negru, 15)
        //o(37, verde, 43)
        //o(38, negru, 33)
        // Din care va alege(36, gri, 13) și(36, negru, 39) și va plăti 52 sau va alege(36, verde, 43) și(36,
        //negru, 32) și va plăti 75 (oricare variantă e corectă).
        static void Main(string[] args)
        {
            // Instantiation of the shop with the shoes added from the database.
            Shop shelf = new Shop(Database.InitializeDatabase());

            // Add a new pair of shoes on the shelf.
            Shoe newShoe = new Shoe(34, "red", 63);
            shelf.Add(newShoe);

            // Verify if the shop has the offer balanced or not.
            Console.WriteLine($"The offer is balanced: {shelf.isBalancedTheOffer()}");

            // Print the list of shoes bought by a client and the price paid.
            // Print the list of shoes that will remain on the shelf after the client bought some of them.
            shelf.Client();
        }
    }
}
