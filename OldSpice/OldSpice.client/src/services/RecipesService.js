import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";


class RecipesService {
  async getAllRecipes() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
  }

  async setActiveRecipe(recipeData) {
    AppState.activeRecipe = recipeData;
  }



}
export const recipesService = new RecipesService();