<template>
  <div class="Recipe-Modal">
    <div class="modal" tabindex="-1" aria-labelledby="Label" aria-hidden="true" id="RecipeModal">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ recipe?.title }}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <h2>instructions</h2>
          <p>{{ recipe?.instructions }}</p>
          <h5>Recipe ingredients</h5>
          <div class="modal-body" v-for="i in ingredients" :key="i.id">
            <span>{{ i.name }}</span>
            <span>{{ i.quantity }}</span>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-primary">Add Ingredient</button>
            <!-- Add instructions -->
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
import { computed } from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    recipe: { type: Recipe, required: false },
    ingredient: { type: Ingredient, required: false },
  },
  setup() {
    async function getIngredientsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await recipesService.getIngredientsByRecipeId(recipeId);

        }
      } catch (error) {
        Pop.error(error);
      }
    }

    watchEffect(() => {
      AppState.activeRecipe;
      getIngredientsByRecipeId();
    })


    return {
      ingredients: computed(() => AppState.ingredients),

      async removeRecipe() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          const recipeId = AppState.activeRecipe.id;
          await recipesService.removeRecipe(recipeId);
          Pop.toast(`${AppState.activeRecipe.title} Removed`, "success", "top-end", 1000);

        } catch (error) {
          Pop.error(error);
        }
      }


    }
  }

}
</script>


<style lang="scss" scoped>

</style>