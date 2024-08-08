import { useRoutes } from "react-router-dom";
import "./App.css";
import LayOut, { DataContext } from "./components/LayOut";
import NoNavBarLayOut from "./components/NoNavBarLayOut";
import AboutUs from "./pages/AboutUs";
import HomePage from "./pages/HomePage";
import Login from "./pages/Login";
import Logout from "./pages/Logout";
import Register from "./pages/Register";
import TestPage from "./pages/Test";
import TypeCreator from "./pages/type/TypeCreator";
import TypeList from "./pages/type/TypeList";
import TypeUpdater from "./pages/type/TypeUpdater";
import Photos from "./pages/Photos";
import CreatePlanDetail from "./pages/PlanDetail/CreatePlanDetail";
import CreatePlan from "./pages/Plan/CreatePlan";
import AllPlans from "./pages/Plan/AllPlans";
import PlanEditor from "./pages/Plan/PlanEditor";
import { useState } from "react";

const App = () => {
  const [globalData, setGlobalData] = useState(null); //{userId: 1, username: 'admin', email: 'admin@example.com', premium: false, birthDate: '2000-01-01T00:00:00', …}
  const routes = useRoutes([
    {
      path: "/",
      element: <LayOut />,
      children: [
        { index: true, element: <HomePage /> },
        { path: "login", element: <Login /> },
        { path: "test", element: <TestPage /> },
        { path: "aboutus", element: <AboutUs /> },
        { path: "register", element: <Register /> },
        { path: "logout", element: <Logout /> },
        { path: "homePage", element: <HomePage /> },

        { path: "typeCreator", element: <TypeCreator /> },
        { path: "typeList", element: <TypeList /> },
        { path: "typeUpdater/:typeId", element: <TypeUpdater /> },
        {
          path: "createPlanDetail",
          element: <CreatePlanDetail />,
        },
        {
          path: "createPlan",
          element: <CreatePlan />,
        },
        {
          path: "plans",
          element: <AllPlans />,
        },
        {
          path: "planEdit/:planId",
          element: <PlanEditor />,
        },

        // Add other routes here
      ],
    },
    {
      path: "photos",
      element: <NoNavBarLayOut />, // Use the new layout for the Photos page
      children: [{ index: true, element: <Photos /> }],
    },
  ]);

  console.log("Routes:", routes); // Temporary logging
  return (
    <DataContext.Provider value={{ globalData, setGlobalData }}>
      {routes}
    </DataContext.Provider>
  );
};

export default App;
