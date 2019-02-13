package ro.eduarddudu.coffeeshop;

import android.location.Location;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.robolectric.RobolectricTestRunner;

import ro.eduarddudu.coffeeshop.Objects.Shop;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
@RunWith(RobolectricTestRunner.class)
public class CsvReaderUnitTest {

    @Before
    public void setup() {
        MockitoAnnotations.initMocks(this);
    }

    @Test
    public void _isValidLineTrue() {
        String[] vars = {"a", "b", "c"};
        assertTrue(CSVReader.INSTANCE.isValidLine(vars));
    }
    @Test
    public void _isValidLineFalseSize() {
        String[] vars2 = {"a", "b", "c", "d"};
        assertFalse(CSVReader.INSTANCE.isValidLine(vars2));
    }
    @Test
    public void _isValidLineFalseEmpty() {
        String[] vars2 = new String[0];
        assertFalse(CSVReader.INSTANCE.isValidLine(vars2));
    }


    @Test
    public void _isValidNameTrue() {
        String[] vars = {"name"};
        assertTrue(CSVReader.INSTANCE.isValidName(vars));
    }

    @Test
    public void _isValidNameFalse() {
        String[] vars = {""};
        assertFalse(CSVReader.INSTANCE.isValidName(vars));
    }


    @Test
    public void _isValidDoubleTrue() {
        String value = "123";
        assertTrue(CSVReader.INSTANCE.isValidDouble(value));
    }
    @Test
    public void _isValidDoubleFalse() {
        String value = "1abc";
        assertFalse(CSVReader.INSTANCE.isValidDouble(value));
    }


    @Test
    public void _isGetshopValid() {
        Location location=new Location("userLocation");
        location.setLatitude(45);
        location.setLongitude(-45);

        Shop shop = new Shop();
        shop.setLocation(location);
        shop.setName("test1");
        shop.setDistance(0);

        String[] vars = {"test1", String.valueOf(location.getLatitude()), String.valueOf(location.getLongitude())};

        assertTrue(areShopsEqual(shop, CSVReader.INSTANCE.getShop(vars)));

    }

    private boolean areShopsEqual(Shop shop1, Shop shop2){
        if (shop1 == null || shop2 ==null) return false;
        if (!shop1.getName().equals(shop2.getName())) return false;
        if (shop1.getDistance() != (shop2.getDistance())) return false;
        if (shop1.getLocation().getLatitude() != (shop2.getLocation().getLatitude())) return false;
        if (shop1.getLocation().getLongitude() != (shop2.getLocation().getLongitude())) return false;

        return true;
    }

}