import { PokemonService } from './../services/pokemon.service';
import { Component, OnInit } from '@angular/core';
import { concatMap, forkJoin, Observable, shareReplay, tap } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  pokemonFullObjects: any[] = [];

  constructor(private pokemonService: PokemonService) { }

  ngOnInit() {
    this.getPokemons().subscribe({
      next: (data: any) => {
        this.pokemonFullObjects = data;
        this.setPokemonPictures();
      }
    });
  }

  getPokemons(term?: string) {
    let pokemonsResponse: any;

    return this.pokemonService.getPokemons(term).pipe(
      tap((pokemons: any) => pokemonsResponse = pokemons),
      concatMap((pokemons: any) => {
        const networkRequestsToMake: Observable<any>[] = pokemons.map((pokemon: any) => this.pokemonService.getPokemonDetails(pokemon.url))
        return forkJoin([...networkRequestsToMake]);
      }),
      shareReplay(1)
    );
  }

  onSearchChange(event: any) {
    return this.getPokemons(event.target.value).subscribe({
      next: (data: any) => {
        this.pokemonFullObjects = data;
        this.setPokemonPictures();
      }, 
      error: (error: string) => {
        console.log(error);
      }
    });
  }

  setPokemonPictures() {
    this.pokemonFullObjects.forEach(element => {
      if (element.sprites.other.home.front_default.includes('...ster')) {
        element.sprites.other.home.front_default.replace('...ster', 'master')
      }
    });
  }
}
