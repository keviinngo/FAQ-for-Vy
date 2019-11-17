export class Question {
    id: number;
    sporsmal: string;
    svar: string;
    ratingOpp: number;
    ratingNed: number;
}

export interface IQuestion {
    id: number;
    sporsmal: string;
    svar: string;
    ratingOpp: number;
    ratingNed: number;
}
