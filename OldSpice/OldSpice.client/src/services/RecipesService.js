import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";


class RecipesService {
  async getAllRecipes() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
  }

  setActiveRecipe(recipeData) {
    AppState.activeRecipe = recipeData;
  }


  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`);
    AppState.ingredients = res.data.map((i) => new Ingredient(i));
    console.log(AppState.ingredients)
  }

  async getRecipeById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`);
    AppState.activeRecipe = new Recipe(res.data);
  }

  async createRecipe(recipeData) {
    const res = await api.post("api/recipes", recipeData);
    console.log("[createRecipe]", res.data);
    const newRecipe = new Recipe(res.data);
    AppState.recipes = [newRecipe, ...AppState.recipes];
  }

  async removeRecipe(recipeId) {
    await api.delete(`api/recipes/${recipeId}`);
    let recipe = AppState.recipes.findIndex((r) => r.id == recipeId);
    AppState.recipes.splic(recipe, 1);
  }

  async editRecipe(recipeId, recipeData) {
    const res = await api.put(`api/recipes/${recipeId}`, recipeData);
    AppState.activeRecipe = new Recipe(res.data);
  }

  getMyRecipes() {
    AppState.recipes = AppState.recipes.filter((r) = r.creator.id == AppState.account.id);
    console.log(AppState.account.id)
  }

  async getRecipesByAccountId() {
    const res = await api.get("api/recipes");
    AppState.recipes = res.data.map((r) => new Recipe(r));
    AppState.recipes = AppState.recipes.filter((r) => r.creator.id == AppState.account.id)
  }



}
export const recipesService = new RecipesService();