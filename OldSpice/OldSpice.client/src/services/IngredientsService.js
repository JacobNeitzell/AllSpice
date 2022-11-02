import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";

class IngredientsService {

  async addIngredient(ingredientdata) {
    const res = await api.get("api/ingredients", ingredientdata);
    console.log(res.data);
    let newIngredient = new Ingredient(res.data)
    AppState.ingredients = [newIngredient, ...AppState.ingredients]

  }

  async removeIngredient(ingredientId) {
    const res = await api.delete(`api/ingredients/${ingredientId}`);
    console.log(res.data);
  }










}
export const ingredientsService = new IngredientsService();