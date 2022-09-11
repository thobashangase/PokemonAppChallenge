import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  apiBaseUrl = 'https://thobashangase-pokemon-api.azurewebsites.net/api';

  constructor(private http: HttpClient) { }

  getPokemons(term?: string) {
    if (term && term !== '') {
      term = term !== '' ? '/filtered/' + term : '';
      return this.http.get(this.apiBaseUrl + '/Pokemon' + term);
    }

    return this.http.get(this.apiBaseUrl + '/Pokemon');
  }

  getPokemonDetails(url: string) {
    return this.http.get(url);
  }
}
