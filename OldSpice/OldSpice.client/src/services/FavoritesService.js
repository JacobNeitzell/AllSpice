import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { api } from "./AxiosService.js";

class FavoritesService {

  async favoriteRecipe(recipe) {
    let newFav = {};
    newFav.recipeId = recipe.id;
    const res = await api.post("api/favorites", newFav);
    recipe.favoriteId = res.data.id;
    recipe.favorited = true
    AppState.favorites.push(recipe);
    console.log(AppState.favorites);
  }

  async removeFavoriteRecipe(favoriteId) {
    await api.delete(`api/favorites/${favoirteId}`);
    let index = AppState.favorites.findIndex(f => f.favoritedId == favoriteId)
    AppState.favorites.splice(index, 1)
  }


  async getAllFaorites(recipeId) {
    const res = await api.get("api/favorites", recipeId);
    AppState.favoritesIds = res.data.map((f) => new FavRecipe(f));
  }

}
export const favoriteService = new FavoritesService();