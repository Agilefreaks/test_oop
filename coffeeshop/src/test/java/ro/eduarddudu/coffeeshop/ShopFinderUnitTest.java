package ro.eduarddudu.coffeeshop;

import android.location.Location;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.MockitoAnnotations;
import org.robolectric.RobolectricTestRunner;

import static org.junit.Assert.assertEquals;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
@RunWith(RobolectricTestRunner.class)
public class ShopFinderUnitTest {

    @Before
    public void setup() {
        MockitoAnnotations.initMocks(this);
    }

    @Test
    public void isExecuted() throws Exception {

        Location location=new Location("user_location");
        //45.796497,24.070577 <Sibiu>
        location.setLatitude(45.796497);
        location.setLongitude(24.070577);

        ShopFinder.INSTANCE.findClosestLocations(location.getLatitude(),location.getLongitude(),getClass().getClassLoader().getResource("coffee_shops.csv").getPath());

    }

    @Test
    public void isDistanceCaluculated() {

        Location location1=new Location("user_location");
        location1.setLatitude(10);
        location1.setLongitude(20);

        Location location2=new Location("user_location");
        location2.setLatitude(10);
        location2.setLongitude(20);

        assertEquals(0.0, ShopFinder.INSTANCE.calculateDistance(location1, location2), 0.0);

    }

}