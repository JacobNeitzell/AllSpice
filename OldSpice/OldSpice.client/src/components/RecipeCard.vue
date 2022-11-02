<template>
  <div class="RecipeCard">
    <div class="card elevation-4" style="width: 18rem;" v-if="recipes">
      <img class="card-img-top forcedImg" :src="recipes.img" :alt="recipes.title" :title="recipes.title + 'img'">
      <div>
        <i class="mdi mdi-heart selectable"></i>
      </div>
      <div class="card-body">
        <span class="cardText p-2 rounded no-select selectable" :title="'Show More Info'" @click="setActiveRecipe()"
          data-bs-target="#RecipeModal" data-bs-toggle="modal">
          <h5 class="card-title text-shadow">{{ recipes.title }}</h5>
          <p class="card-text text-shadow2">{{ recipes.category }}
          </p>
        </span>
      </div>
    </div>
  </div>

</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  props: {
    recipes: { type: Recipe, required: true },
  },
  setup() {
    return {
      setActiveRecipe() {
        recipesService.setActiveRecipe(props.recipes);
      },



    }
  }
}
</script>


<style lang="scss" scoped>
.text-shadow {
  color: rgba(41, 56, 84, 0.855);
  text-shadow: 1px 1px rgba(0, 197, 246, 0.941), 0px 0px 5px rgb(96, 74, 96);
  font-weight: bold;
  letter-spacing: 0.08rem
}

.text-shadow2 {
  color: rgba(0, 98, 244, 0.823);
  text-shadow: 1px 1px rgba(199, 167, 223, 0.477), 0px 0px 5px rgb(46, 38, 46);
  font-weight: bold;
  letter-spacing: 0.08rem
}

.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(223, 12, 132, 0.4) 5px 5px, rgba(88, 3, 101, 0.3) 10px 10px,
    rgba(175, 8, 138, 0.2) 15px 15px, rgba(60, 45, 6, 0.1) 20px 20px;
}


.forcedImg {
  height: 300px;
  width: auto;
  object-fit: cover;
}
</style>