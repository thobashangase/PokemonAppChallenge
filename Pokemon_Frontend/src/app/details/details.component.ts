import { PokemonService } from './../services/pokemon.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  routeData: any;
  pokemon: any;

  constructor(private router: Router) {
    this.routeData = this.router.getCurrentNavigation()!.extras.state;
    this.pokemon = this.routeData[0].pokemon;
  }

  ngOnInit() {
  }

  setPokemonPictures() {
    if (this.pokemon.sprites.other.home.front_default.includes('...ster')) {
      this.pokemon.sprites.other.home.front_default.replace('...ster', 'master')
    }
  }
}
