<template>
  <div class="home">
    <!-- Hero Section -->
    <section class="min-h-[60vh] bg-cover bg-center bg-[#163963] text-white flex flex-col justify-center items-center"
      style="background-image: url(https://source.unsplash.com/featured/?workout,fitness);">

      <!-- Welcome Box -->
      <div class="bg-black bg-opacity-60 p-6 rounded-lg shadow-lg max-w-md text-center flex flex-col items-center">
        <!-- Logo at the top -->
        <img src="@/assets/logo.svg" alt="Gains Before Grooms Logo" class="w-1/2 mb-8">
        <h1 class="text-3xl font-bold mb-4">Welcome to Gains Before Grooms (GBG)</h1>
        <p class="text-base mb-4">
          Track workouts, connect with friends, and stay motivated together. GBG helps you log your progress and
          notifies you when your friends reach new milestones.
        </p>
        <p class="text-base mb-4">
          Push your limits, stay consistent, and achieve your fitness goals!
        </p>
      </div>
    </section>

    <!-- Features Section (Optional) -->
    <section class="bg-gray-100 py-16 text-gray-800">
      <div class="container mx-auto px-6">
        <h2 class="text-3xl font-bold text-center mb-12">Why GBG?</h2>
        <div class="flex flex-wrap justify-center">
          <div class="w-full sm:w-1/3 p-4 text-center">
            <div class="bg-white shadow-md rounded-lg p-6">
              <h3 class="font-bold text-xl mb-3">Track Your Progress</h3>
              <p>Log your workouts, reps, and sets. Stay consistent and hit your fitness goals.</p>
            </div>
          </div>
          <div class="w-full sm:w-1/3 p-4 text-center">
            <div class="bg-white shadow-md rounded-lg p-6">
              <h3 class="font-bold text-xl mb-3">Connect with Friends</h3>
              <p>Add friends to your workout circle and keep each other accountable.</p>
            </div>
          </div>
          <div class="w-full sm:w-1/3 p-4 text-center">
            <div class="bg-white shadow-md rounded-lg p-6">
              <h3 class="font-bold text-xl mb-3">Get Notifications</h3>
              <p>Get real-time notifications when your friends complete workouts or achieve milestones.</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: 'HomeView'
}
</script>
