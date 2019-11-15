import { Component } from '@angular/core';
import { Kunde } from './kunde';

@Component({
  selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})


export class HomeComponent {
    /*
    public navn: string;
    public sporsmal: string;

    public kunder: Array<Kunde> = [];

    leggTilKunde(): void {
        var kunde = new Kunde(this.navn, this.sporsmal);
        this.kunder.push(kunde);
        this.navn = "";
        this.sporsmal = "";
    }

    slettKunde(kunde: Kunde): void {
        var indeks = this.kunder.indexOf(kunde);
        this.kunder.splice(indeks, 1);
    }
    */
}
