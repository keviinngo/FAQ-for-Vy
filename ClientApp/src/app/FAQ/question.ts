export class Question {
    id: number;
    sporsmal: string;
    svar: string;
    ratingOpp: number;
    ratingNed: number;
    /*
    constructor(id: number,
        sporsmal: string,
        svar: string,
        ratingOpp: number,
        ratingNed: number) {
        this.id = id;
        this.sporsmal = sporsmal;
        this.svar = svar;
        this.ratingOpp = ratingOpp;
        this.ratingNed = ratingNed;
    }
    */
}

export interface IQuestion {
    id: number;
    sporsmal: string;
    svar: string;
    ratingOpp: number;
    ratingNed: number;
}
