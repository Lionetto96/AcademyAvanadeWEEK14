# Esercitazione

1. Realizzare una applicazione web per un servizio di gestione Ticket di supporto IT

    **Ticket**
    - Data di creazione
    - Richiedente
    - Descrizione Breve
    - Descrizione Lunga
    - Priorit&agrave; (Alta, Normale, Bassa)
    - Categoria (System, Development, Office Application, SAP, ... )
    - Stato (Nuovo, Assegnato, In Risoluzione, Chiuso)
    - Assegnatario (gestore del Ticket)
    - Data di Chiusura

    **Note**
    - Testo
    - Data di creazione

2. Realizzare il Data Layer utilizzando EF Core (Code first) e il Repository Pattern.

3. Integrare il BL in una applicazione MVC

4. Realizzare un `TicketController` per gestire le seguenti viste
    - Lista dei Ticket
        - Integrare le operazioni di Assegnamento e Chiusura di un Ticket nella lista
        - Mostrare il numero di Note allegate ad un Ticket
    - Creazione di un Nuovo Ticket
    - Visualizzazione dettagli di un Ticket
        - Permettere l'aggiunta di una nuova Nota
    - Edit di un Ticket
        - Permettere l'aggiunta di una nuova Nota
    - Cancellazione di un Ticket

5. Realizzare la gestione delle Categorie come anagrafica dell'applicazione
    - Implementare le operazioni di CRUD
    - La gestione delle Categorie pu&ograve; essere effettuata solo da un utente Admin
    - Ridefinire l'insieme dei campi utilizzati per inserire un Nuovo Ticket e per Modificare un Ticket come Partial View ed adottarla nelle due viste relative

6. Realizzare un *Tag Helper* per la selezione della Priorit&agrave; sulle form di gestione dei ticket
