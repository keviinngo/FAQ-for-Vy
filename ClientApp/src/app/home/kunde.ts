export class Kunde {
    public utData: string;

    constructor(navn: string, sporsmal: string) {
            this.utData = navn + " : " + sporsmal;
        }
}
